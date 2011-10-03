﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ploeh.Samples.Booking.WebModel
{
    public class BookingController : Controller
    {
        private readonly IReader<DateTime, int> remainingCapacityReader;

        public BookingController(IReader<DateTime, int> remainingCapacityReader)
        {
            this.remainingCapacityReader = remainingCapacityReader;
        }

        public ViewResult Get(DateViewModel id)
        {
            var date = id.ToDateTime();
            var remainingCapacity = this.remainingCapacityReader.Query(date);
            return this.View(
                new BookingViewModel
                {
                    Date = id.ToDateTime(),
                    Remaining = remainingCapacity
                });
        }

        [HttpPost]
        public ViewResult Post(BookingViewModel model)
        {
            return this.View("Receipt", model);
        }
    }
}