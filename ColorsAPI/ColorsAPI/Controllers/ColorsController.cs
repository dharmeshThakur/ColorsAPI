using Colors.Data;
using ColorsAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ColorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        /// <summary>
        /// Property to inject dependency
        /// </summary>
        private IColorsRepository colorRepository;
        /// <summary>
        /// Constructor with colors repository injected
        /// </summary>
        /// <param name="colorRepository"></param>
        public ColorsController(IColorsRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        /// <summary>
        /// To get all colors
        /// </summary>
        /// <returns>List of colors</returns>
        [HttpGet]
        public async Task<ActionResult<ResultModel>> Index()
        {
            var result = await colorRepository.GetAllColors();            
            var viewmodel = new List<ColorsViewModel>();
            foreach (var color in result)
            {
                var data = new ColorsViewModel
                {
                    Category = color.Category,
                    Name = color.Name,
                    Type = color.Type,
                    Id = color.Id,
                    Code = new Model.Code
                    {
                        RGBA = color.RGBA.Select(x => Int32.Parse(x)).ToList(),
                        Hex = color.Hex
                    }
                };
                viewmodel.Add(data);
            }
            ResultModel resultModel = new ResultModel();
            resultModel.StatusCode = "200";
            resultModel.Message = "Success";
            resultModel.Body = JsonSerializer.Serialize(viewmodel);
            return (resultModel);
        }
        
        /// <summary>
        /// To Add new color
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Saved Color</returns>
        [HttpPut]
        public async Task<ActionResult<ResultModel>> AddColor(ColorsViewModel model)
        {
            Colors.Data.Colors color = new Colors.Data.Colors();

            color.Category = model.Category;
            color.Hex = model.Code.Hex;
            color.Name = model.Name;
            color.RGBA = model.Code.RGBA.Select(i => i.ToString()).ToArray(); ;
            color.Type = model.Type;

            var result = await colorRepository.SaveColor(color);            
            ResultModel resultModel = new ResultModel();
            resultModel.StatusCode = "200";
            resultModel.Message = result;
            resultModel.Body = JsonSerializer.Serialize(color);           
            return (resultModel);
        }

        /// <summary>
        /// To update color
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success</returns>
        [HttpPost]
        public async Task<ActionResult<ResultModel>> UpdateColor(ColorsViewModel model)
        {
            Colors.Data.Colors color = new Colors.Data.Colors();
            color = await colorRepository.GetColor(model.Id);
            color.Category = model.Category;
            color.Hex = model.Code.Hex;
            color.Name = model.Name;
            color.RGBA = model.Code.RGBA.Select(i => i.ToString()).ToArray(); ;
            color.Type = model.Type;

            var result = await colorRepository.UpdateColor(color);
            ResultModel resultModel = new ResultModel();
            resultModel.StatusCode = "200";
            resultModel.Message = result;
            resultModel.Body = JsonSerializer.Serialize(color);
            return (resultModel);            
        }

        /// <summary>
        /// To delete color
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Success</returns>
        [HttpDelete]
        public async Task<ActionResult<ResultModel>> DeleteColor(int id)
        {            
            var result = await colorRepository.DeleteColor(id);
            ResultModel resultModel = new ResultModel();
            resultModel.StatusCode = "200";
            resultModel.Message = result;
            resultModel.Body = "";
            return (resultModel);
        }

        /// <summary>
        /// To get single color data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Color Data</returns>
        [HttpGet]
        [Route("GetColor")]
        public async Task<ActionResult<ResultModel>> GetColor(int id)
        {
            var result = await colorRepository.GetColor(id);
            ResultModel resultModel = new ResultModel();
            resultModel.StatusCode = "200";
            resultModel.Message = "Success";
            resultModel.Body = JsonSerializer.Serialize(result);
            return (resultModel);
        }
    }
}
