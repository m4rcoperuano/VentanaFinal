using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using VentanaFinal.Core;
using VentanaFinal.Core.Interfaces;
using VentanaFinal.Infrastructure.Models.Cards;

namespace VentanaFinal.Infrastructure.Services
{
    public class CardService
    {
        private IRepository _repository { get; set; }
        public CardService(IRepository repository)
        {
            this._repository = repository;
        }

        public int SaveNewCard(CardModel cardModel, int createdByUserId)
        {
            Card card = Mapper.Map<Card>(cardModel);
            card.CreatedOn = DateTime.Now;
            card.UpdatedOn = DateTime.Now;
            card.CreatedBy = createdByUserId;

            this._repository.Add(card);
            this._repository.CommitAndDispose();

            return card.id_card;
        }

        public CardModel GetCard(int cardId)
        {
            Card card = _repository.Single<Card>(x => x.id_card == cardId);
            IEnumerable<Card_WordingTemplates> wordingTemplates = card.Card_WordingTemplates;
            CardModel cardModel = Mapper.Map<CardModel>(card);
            cardModel.WordingTemplates = Mapper.Map<List<WordingTemplateModel>>(wordingTemplates.ToList());
            cardModel.IdCard = card.id_card;

            return cardModel;
        }

        public List<WordingTemplateModel> GetCardWordingTemplates(int cardId)
        {
            IEnumerable<Card_WordingTemplates> wordingTemplates = this._repository.Many<Card_WordingTemplates>
                (x => x.fk_card == cardId);
            List<WordingTemplateModel> wordingTemplateModels =
                Mapper.Map<List<WordingTemplateModel>>(wordingTemplates.ToList());

            return wordingTemplateModels;
        }

        public void SaveWordingTemplate(WordingTemplateModel wordingTemplateModel)
        {
            Card_WordingTemplates cardWordingTemplate = Mapper.Map<Card_WordingTemplates>(wordingTemplateModel);
            cardWordingTemplate.CreatedOn = DateTime.Now;
            cardWordingTemplate.UpdatedOn = DateTime.Now;
         
            this._repository.Add(cardWordingTemplate);
            this._repository.CommitAndDispose();
        }
    }
}
