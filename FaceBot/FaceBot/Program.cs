using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceBot.Business;

namespace FaceBot
{
    class Program
    {
        static void Main(string[] args)
        {
            new FacebookBusiness().LoginAndRedirectPostFacebook();
        }
    }
}
