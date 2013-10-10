using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using VentanaFinal.Core;
using VentanaFinal.Core.Interfaces;
using VentanaFinal.Core.Repositories;
using VentanaFinal.Infrastructure.Models.Cards;
using VentanaFinal.Interfaces;
using VentanaFinal.Services;

namespace VentanaFinal
{
    public static class AppBootstrapper
    {
        public static IUnityContainer UnityContainer;
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            AppBootstrapper.UnityContainer = container;

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            RegisterMaps();

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMembership, Membership>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IFileHandler, FileHandler>();
        }

        public static void RegisterMaps()
        {
            Mapper.CreateMap<Card, CardModel>();
            Mapper.CreateMap<CardModel, Card>();

            Mapper.CreateMap<Card_WordingTemplates, WordingTemplateModel>();
            Mapper.CreateMap<WordingTemplateModel, Card_WordingTemplates>();
        }
    }
}