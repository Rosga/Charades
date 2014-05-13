using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Charades.Domain.Abstract;
using Charades.Domain.Concrete;
using Charades.Domain.Entities;
using Moq;
using Ninject;

namespace Charades.WebUI.Infrastructure
{
    //Класс DI фабрики
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance
            (RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)_ninjectKernel.Get(controllerType);
        }

        //Добавление привязок
        private void AddBindings()
        {
            //Mock<ICharadeRepository>  mock = new Mock<ICharadeRepository>();

            //mock.Setup(m => m.Words).Returns(new List<Word>
            //{
            //    new Word {Name = "Footbal", LevelId = 2},
            //    new Word {Name = "Surf", LevelId = 3}
            //}.AsQueryable());

            //_ninjectKernel.Bind<ICharadeRepository>().ToConstant(mock.Object);
            //Здесь размещаются привязки
            _ninjectKernel.Bind<ICharadeRepository>().To<EFCharadesRepository>();
        }
    }
}