using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Boardgames.Common
{
    public class ValidationConstants
    {
        // Boardgame
        public const int BoardGameNameMaxLength = 20;
        public const double BoardGameRatingMaxLength = 10.00;
        public const int BoardGameYearPublishedMaxLength = 2023;

        public const int BoardGameNameMinLength = 10;
        public const double BoardGameRatingMinLength = 1.00;
        public const int BoardGameYearPublishedMinLength = 2018;

        public const int BoardGameCategoryTypeMinLength = 0;
        public const int BoardGameCategoryTypeMaxLength = 4;

        // Seller
        public const int SellerNameMaxLength = 20;
        public const int SellerAddressMaxLength = 30;

        public const int SellerNameMinLength = 5;
        public const int SellerAddressMinLength = 2;

        public const string WebsiteRegEx =
            @"^www\.[a-zA-Z0-9-]+\.com";

        // Creator
        public const int CreatorFirstNameMaxLength = 7;
        public const int CreatorLastNameMaxLength = 7;

        public const int CreatorFirstNameMinLength = 2;
        public const int CreatorLastNameMinLength = 2;
    }
}
