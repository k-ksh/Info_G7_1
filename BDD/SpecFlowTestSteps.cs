﻿using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace BDD
{
    [Binding]
    public class SpecFlowTestSteps
    {
        private int _firstNumber;
        private int _secondNumber;
        private int _result;

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _firstNumber = number;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _secondNumber = number;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _firstNumber + _secondNumber;
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedSum)
        {
            Assert.True(_result == expectedSum, "Error message");
        }
    }
}
