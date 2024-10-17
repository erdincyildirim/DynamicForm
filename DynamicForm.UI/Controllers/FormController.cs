using DynamicForm.Business.Abstract;
using DynamicForm.DataTransfer.DTOs;
using DynamicForm.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace DynamicForm.UI.Controllers
{
    [Authorize]
    public class FormController : Controller
    {

        private readonly IFormService _formService;

		public FormController(IFormService formService)
		{
			_formService = formService;
		}

		ResultVM _result = new();

        public IActionResult Index()
        {

			return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFormDto createFormDto)
        {

            if (ModelState.IsValid)
            {
                createFormDto.CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _formService.AddAsync(createFormDto);
                _result.Status = true;
                _result.Message = "Yeni Form Eklendi !";

            }
            else
            {
                _result.Status = false;
                _result.Message = "Form Eklenemedi !";
            }

            return Json(_result);

        }

        public async Task<IActionResult> GetAll()
        {

            return Json(await _formService.GetAllAsync());

        }

        [HttpPost]
        public async Task<IActionResult> DeleteForm(int id)
        {
            await _formService.SoftDeleteAsync(id);
			_result.Status = true;
			_result.Message = "Form Silindi !";
			return Json(_result);

        }

		[HttpGet("/forms/{formId}")]
		public async Task<IActionResult> Form(int formId)
        {
            var fieldsjson = await _formService.GetByIdAsync(formId);
			var fields = JsonConvert.DeserializeObject<List<FormVM>>(fieldsjson.Fields);
			return View(fields);
        }

    }
}
