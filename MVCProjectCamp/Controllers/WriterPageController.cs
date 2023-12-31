﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Antlr.Runtime;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProjectCamp.Controllers
{
	public class WriterPageController : Controller
	{
		// GET: WriterPage
		HeaderManager _headerManager = new HeaderManager(new EfHeaderDal());
		CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
		WriterManager _writerManager = new WriterManager(new EfWriterDal());
		Context context = new Context();

		[HttpGet]
		public ActionResult WriterProfile(int id = 0)
		{
			string p = (string)Session["WriterMail"];
			id = context.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterId).FirstOrDefault();
			var writerValue = _writerManager.GetById(id);
			return View(writerValue);
		}
		[HttpPost]
		public ActionResult WriterProfile(Writer writer)
		{
			WriterValidator writerValidator = new WriterValidator();
			ValidationResult results = writerValidator.Validate(writer);
			if (results.IsValid)
			{
				_writerManager.WriterUpdate(writer);
				return RedirectToAction("AllHeaders","WriterPage");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public ActionResult MyHeading(string p)
		{

			p = (string)Session["WriterMail"];
			var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
			var values = _headerManager.GetListByWriter(writerIdInfo);
			return View(values);
		}
		[HttpGet]
		public ActionResult NewHeading()
		{
			List<SelectListItem> valueCategory = (from x in _categoryManager.GetList() //DropDownList
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryId.ToString()
												  }).ToList();
			ViewBag.vlc = valueCategory;
			return View();
		}
		[HttpPost]
		public ActionResult NewHeading(Header header)
		{
			string writerMailInfo = (string)Session["WriterMail"];
			var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
			header.HeaderDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			header.WriterId = writerIdInfo;
			header.HeaderStatus = true;
			_headerManager.HeaderAdd(header);
			return RedirectToAction("MyHeading");
		}
		public ActionResult EditHeader(int id)
		{
			List<SelectListItem> valueCategory = (from x in _categoryManager.GetList() //DropDownList
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryId.ToString()
												  }).ToList();
			ViewBag.vlc = valueCategory;
			var headerValue = _headerManager.GetById(id);
			return View(headerValue);
		}
		[HttpPost]
		public ActionResult EditHeader(Header header)
		{
			_headerManager.HeaderUpdate(header);
			return RedirectToAction("MyHeading");
		}
		public ActionResult DeleteHeader(int id)
		{
			var headerValue = _headerManager.GetById(id);
			headerValue.HeaderStatus = false;
			_headerManager.HeaderDelete(headerValue);
			return RedirectToAction("MyHeading");
		}
		public ActionResult AllHeaders(int p = 1)
		{
			var headers = _headerManager.GetList().ToPagedList(p, 8);
			return View(headers);
		}

	}
}

//< customErrors mode = "On" >

//    < error statusCode = "404" redirect = "/ErrorPage/Page404/" ></ error >

//</ customErrors >