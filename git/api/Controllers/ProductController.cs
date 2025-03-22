using api.services;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers;

public class ProductController(IProductService produts) : ControllerBase {

  [HttpPost]
  [Route("/product/add")]
  public IActionResult Add([FromBody] ProductModel p)
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

  [HttpDelete]
  [Route("/product/delete")]
  public IActionResult Delete([FromQuery] int id){
    produts.Remove(id);
    return  Ok();
  }

  [HttpPatch]
  [Route("/product/update")]
  public IActionResult Update([FromBody] Product p){

    if (!ModelState.IsValid){
      return BadRequest("Invalid model");
    }

    produts.Update(p);
    return  Ok();
  }

}
