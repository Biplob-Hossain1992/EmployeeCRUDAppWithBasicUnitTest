using EmployeeCRUDApp.Application.Interfaces.IServices;
using EmployeeCRUDApp.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUDApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReviewController : ControllerBase
    {
        private readonly IPerformanceReviewService _reviewService;
        public PerformanceReviewController(IPerformanceReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [Route("CreateReview")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> CreateReview(VmReview vm)
        {
            vm.ReviewDate = Convert.ToDateTime(vm.FormatedDate);
            return Ok(await _reviewService.CreateReview(vm));
        }
        [Route("GetAllReview")]
        [HttpGet]
        public async Task<ActionResult<List<VmDepartment>>> GetAllReview()
        {
            return Ok(await _reviewService.GetAllReview());
        }
        [Route("GetAllReviewForDataTable")]
        [HttpPost]
        public async Task<ActionResult<List<VmReview>>> GetAllReviewForDataTable()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            var data = await _reviewService.GetAllReview();

            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                data = data.Where(x => x.EmployeeName.ToLower().Contains(searchValue.ToLower())).ToList();
            }
            int recordsTotal = data.Count;
            data = data.Skip(skip).Take(pageSize).ToList();
            return Ok(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
        }
        [Route("GetReviewById")]
        [HttpGet]
        public async Task<ActionResult<VmReview>> GetReviewById(int id)
        {
            return Ok(await _reviewService.GetReviewById(id));
        }
        [Route("UpdateReview")]
        [HttpPost]
        public async Task<ActionResult<VmResponseMessage>> UpdateReview(VmReview vm)
        {
            vm.ReviewDate = Convert.ToDateTime(vm.FormatedDate);
            return Ok(await _reviewService.UpdateReview(vm));
        }
        [Route("RemoveReview")]
        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveReview(int id)
        {
            return Ok(await _reviewService.RemoveReview(id));
        }
        [Route("GetAverageScore")]
        [HttpGet]
        public async Task<ActionResult<List<VmAverageScore>>> GetAverageScore()
        {
            return Ok(await _reviewService.GetAverageScore());
        }
    }
}
