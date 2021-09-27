// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: September 26, 2021
//    Written By: Devanshi Patel
//    Student ID: 100805084
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.


using System.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace IncIncPieceworkPayroll
{
    class PieceworkWorker
    {
        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private int employeeMessages;
        private decimal employeePay;

        private bool isValid = true;

        // Shared class variables
        private static int overallNumberOfEmployees;
        private static int overallMessages;
        private static decimal overallPayroll;
        private static decimal employeeAverage;

        //Constants
        private static int MinimumMessageSent = 1;
        private static int MessageSent1 = 1250;
        private static int MessageSent2 = 2500;
        private static int MessageSent3 = 3750;
        private static int MessageSent4 = 5000;
      
        private static decimal PayPerMessage1 = 0.02M;
        private static decimal PayPerMessage2 = 0.024M;
        private static decimal PayPerMessage3 = 0.028M;
        private static decimal PayPerMessage4 = 0.034M;
        private static decimal PayPerMessage5 = 0.04M;

        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public PieceworkWorker(string nameValue, string messagesValue)
        {
            // Validate and set the worker's name
            this.Name = nameValue;
            // Validate Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Calculcate the worker's pay and update all summary values
            FindPay();
        }

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public PieceworkWorker()
        {

        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the FindPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
        private void FindPay()
        {
            if(isValid)
            {
                if(employeeMessages>=MinimumMessageSent && employeeMessages<MessageSent1)
                {
                    employeePay = employeeMessages * PayPerMessage1;
                }
                else if(employeeMessages>=MessageSent1 && employeeMessages<MessageSent2)
                {
                    employeePay = employeeMessages * PayPerMessage2;
                }
                else if (employeeMessages >= MessageSent2 && employeeMessages <MessageSent3)
                {
                    employeePay = employeeMessages * PayPerMessage3;
                }
                else if (employeeMessages >= MessageSent3 && employeeMessages <MessageSent4)
                {
                    employeePay = employeeMessages * PayPerMessage4;
                }
                else 
                {
                    employeePay = employeeMessages * PayPerMessage5;
                }
            }

            //Update all summary values.
            overallNumberOfEmployees++;
            overallMessages += employeeMessages;
            overallPayroll += employeePay;
        }

        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                return employeeName;
            }
            set
            {
                //employeeName = value;
                // TO DO
                // Add validation for the worker's name based on the requirements
                // document
                if (string.IsNullOrEmpty(value))
                {
                    isValid = false;
                    MessageBox.Show("The worker's name cannot be empty.");
                    
                }

                employeeName = value;
            }
        }

        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                return employeeMessages.ToString();
            }
            set
            {
                //Check the number of message sent
                if(int.TryParse(value, out employeeMessages))
                {
                    //If message is less than 0
                    if(employeeMessages < 0)
                    {
                        // Gives an error message box
                        isValid = false;
                        MessageBox.Show("The worker's messages must be more than " , "Entry Error");
                    }
                }
                //Check if it is empty or not
                else
                {
                    //Gives an error message box when it is empty
                    isValid = false;
                    MessageBox.Show("Please enter the number of messages that sent by the worker.");
                }
            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay
        {
            get
            {
                return employeePay;
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {
                return overallPayroll;
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers
        {
            get
            {
                return overallNumberOfEmployees;
            }
        }

        /// <summary>
        /// Gets the overall number of messages sent
        /// </summary>
        /// <returns>the overall number of messages sent</returns>
        public static int TotalMessages
        {
            get
            {
                return overallMessages;
            }
        }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {
            get
            {
                return employeeAverage;
            }
            set
            {
                 employeeAverage = overallPayroll / overallNumberOfEmployees;
            }
        }

        #endregion

    }
}
