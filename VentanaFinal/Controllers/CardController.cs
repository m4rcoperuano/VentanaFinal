using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentanaFinal.Core;
using VentanaFinal.Core.Interfaces;
using VentanaFinal.Infrastructure.Models.Cards;
using VentanaFinal.Infrastructure.Services;
using VentanaFinal.Interfaces;

namespace VentanaFinal.Controllers
{
    public class CardController : Controller
    {
        private IFileHandler _fileHandler;
        private IMembership _membership;
        private IRepository _repository;
        public CardController(IFileHandler fileHandler, IMembership membership, IRepository repository)
        {
            this._fileHandler = fileHandler;
            this._membership = membership;
            this._repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CardModel cardModel, HttpPostedFileBase frontCardImage,
            HttpPostedFileBase backCardImage, HttpPostedFileBase featuredCardImage)
        {
            string cardPath = "/ProductFiles/Cards/";
            Tuple<int, string> companyInfo = this._membership.GetCompanyIdAndName();
            cardPath += companyInfo.Item2 + "_" + companyInfo.Item1 + "/";

            string featuredCardPath = "",
                frontCardPath = "",
                backCardPath = "";

            featuredCardPath = this._fileHandler.UploadFile(featuredCardImage, cardPath);
            frontCardPath = this._fileHandler.UploadFile(frontCardImage, cardPath);
            backCardPath = this._fileHandler.UploadFile(backCardImage, cardPath);

            cardModel.FrontImage = frontCardPath;
            cardModel.BackImage = backCardPath;
            cardModel.FeaturedImage = featuredCardPath;

            CardService cardService = new CardService(this._repository);
            int cardId = cardService.SaveNewCard(cardModel, this._membership.UserId());

            return RedirectToAction("Edit", new { id = cardId });
        }

        public ActionResult Edit(int id)
        {
            CardService cardService = new CardService(_repository);
            CardModel cardModel = cardService.GetCard(id);

            return View(cardModel);
        }

        //AJAX From here forward
        [HttpPost]
        public PartialViewResult AddWordingTemplatePartialViewResult(string newWordingTemplateName, int cardId)
        {
            WordingTemplateModel wordingTempModel = new WordingTemplateModel();
            wordingTempModel.TemplateName = newWordingTemplateName;
            wordingTempModel.fk_card = cardId;
            
            CardService cardService = new CardService(_repository);
            cardService.SaveWordingTemplate(wordingTempModel);
            _repository.NewContext();
            List<WordingTemplateModel> wordingTemplates = cardService.GetCardWordingTemplates(cardId);
            return PartialView("_WordingTemplateList", wordingTemplates);
        }
    }
}
