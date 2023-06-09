﻿using AutomationFramework.Pages;
using SeleniumExtras.PageObjects;
using System;

namespace AutomationFramework.Utils
{
    /// <summary>
    /// Klasa koja inicijalicuje potrebnu stranicu
    /// </summary>
    public class AllPages
    {
        public AllPages(Browsers browser)
        {
            _browser = browser;
        }
        Browsers _browser { get; }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.GetDriver);
            PageFactory.InitElements(_browser.GetDriver, page);
            return page;
        }
        public RegisterUserPage RegisterUserPage => GetPages<RegisterUserPage>();
        public HomePage HomePage => GetPages<HomePage>();   
        public LogInPage LogInPage => GetPages<LogInPage>();
        public AccountPage AccountPage => GetPages<AccountPage>();
        public CheckOutPage CheckOutPage => GetPages<CheckOutPage>();
        public ContactUsPage ContactUsPage => GetPages<ContactUsPage>();
        public ForgotLoginPage ForgotLoginPage => GetPages<ForgotLoginPage>();
        public ForgotPasswordPage ForgotPasswordPage => GetPages<ForgotPasswordPage>();
        public CartPage CartPage => GetPages<CartPage>();
        public ProductPage ProductPage => GetPages<ProductPage>();  
    }
}
