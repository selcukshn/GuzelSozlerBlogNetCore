using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.Data.Abstract;

namespace web.ViewComponents.NavbarViewComponent
{
    public class NavbarViewComponent : ViewComponent
    {
        private IUnitOfWork _unitOfWork;
        public NavbarViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            return View(_unitOfWork.Categories.GetAll());
        }
    }
}