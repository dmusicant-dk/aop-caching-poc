using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AopTest.Service
{
    /*
     * This exists because Spring.Net AOP *must* have an interface. It cannot 
     * create proper pointcuts on classes.
     */
    public interface ItemService
    {
        string getItem(string name);
    }
}