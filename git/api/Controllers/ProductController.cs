using api.services;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers;

public class ProductController(IProductService produts) : ControllerBase {

  [HttpGet]
  [Route("/product/all")]
  public IActionResult GetAll(){
    return Ok(produts.GetAll());
  }

}
