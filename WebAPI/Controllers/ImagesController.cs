﻿using Business.Abstract;
using CloudinaryDotNet.Actions;
using Core.Utilities.Cloudinaryy;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;
        CloudinaryService _cloudinaryService;

        public ImagesController(IImageService imageService, CloudinaryService cloudinaryService)
        {
            _imageService = imageService;
            _cloudinaryService = cloudinaryService;
        }

        [HttpGet("getbyitemid")]
        public IActionResult GetByItemId(int itemId)
        {
            var result = _imageService.GetByItemId(itemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("upload")]
        public IActionResult Upload(int itemId,[FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            ImagePath image = new ImagePath();
            var uploadResult = _cloudinaryService.Upload(file);
            image.ItemId = itemId;
            image.Name = (String)uploadResult.OriginalFilename;
            image.ImageUrl = (String)uploadResult.Url.ToString();
            image.ImageId = (String)uploadResult.PublicId;

          IResult result =  _imageService.Upload(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
