﻿using Business.Abstract;
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
    public class CreditCardsController : ControllerBase
    {
        private ICreditCardService _cardService;

        public CreditCardsController(ICreditCardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard card)
        {
            var result = _cardService.Add(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(CreditCard card)
        {
            var result = _cardService.Delete(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deletebycardid")]
        public IActionResult DeleteByCardId([FromBody] int cardId)
        {
            var result = _cardService.DeleteById(cardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int cardId)
        {
            var result = _cardService.GetById(cardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycardnumber")]
        public IActionResult GetByCardNumber(string cardNumber)
        {
            var result = _cardService.GetByCardNumber(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("iscardexist")]
        public IActionResult IsCardExist(CreditCard card)
        {
            var result = _cardService.IsCardExist(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);

        }
        [HttpPost("update")]
        public IActionResult Update(CreditCard card)
        {
            var result = _cardService.Update(card);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcreditcardbycustomerid")]

        public IActionResult GetAllCreditCardByCustomerId(int customerId)
        {
            var result = _cardService.GetAllCreditCardByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
