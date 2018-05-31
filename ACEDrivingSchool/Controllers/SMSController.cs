// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 05-29-2018
//
// Last Modified By : Ben
// Last Modified On : 05-29-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ACEDrivingSchool.Models;
using Microsoft.AspNet.Identity;
using Nexmo.Api;

namespace ACEDrivingSchool.Controllers
{
    /// <summary>
    /// Class SMSController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class SMSController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="SMSController" /> class.
        /// </summary>
        public SMSController()
        {
            _context = new ApplicationDbContext();

        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Method for sending an sms message to the customer after they have booked a lesson
        /// </summary>
        /// <param name="lesson">The lesson.</param>
        public void SendMessage(Lesson lesson)
        {
            //this code block will find the Id of the customer and set the variable phoneNumber to the one associated with the mobile number of that customer
            var currentUserId = User.Identity.GetUserId();
            var customer = _context.Customers.Find(currentUserId);
            var phoneNumber = "";

            if (customer == null)
            {

                currentUserId = lesson.CustomerId;

                var customerInDb = _context.Customers.Find(currentUserId);

                phoneNumber = customerInDb.MobilePhoneNumber;




            }
            else
            {
                phoneNumber = customer.MobilePhoneNumber;

            }

            //at current this method does not work but I left it in to show the attempt
            //builds and sends the sms message
            var text = "Your lesson at " + lesson.DateTimeOfLesson + " has been booked.";
            var results = SMS.Send(new SMS.SMSRequest
            {
                from = Configuration.Instance.Settings["appsettings:NEXMO_FROM_NUMBER"],
                to = phoneNumber,
                text = text
            });
        }
    }
}