using api.services;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers;

public class ProductController(IProductService produts) : ControllerBase {

  [HttpPost]
  [Route("/product/add")]
  public IActionResult Add([FromBody] Product p)
  {
    if (!ModelState.IsValid){
      return BadRequest("Invalid model");
    }

    if(!produts.Add(p)){
      return BadRequest("Failed insertion");
    }

    return Ok();
  }

  [HttpGet]
  [Route("/product/all")]
  public IActionResult GetAll()
  {
    return Ok(produts.GetAll());
  }

}
