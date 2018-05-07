using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using System.Collections.Generic;

namespace GummiBearKingdomTests.Model_Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void Constructor_ReviewConstructorCreatesReview_Review()
        {
            Review testReview = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", Rating = 5 };

            Assert.AreEqual(testReview.UserName, "A User");
        }
        [TestMethod]
        public void Getters_GetReviewData_Review()
        {
            Review testReview = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", Rating = 5 };

            var idResult = testReview.ReviewId;
            var userResult = testReview.UserName;
            var bodyResult = testReview.Body;
            var ratingResult = testReview.Rating;

            Assert.AreEqual(idResult, 1);
            Assert.AreEqual(userResult, "A User");
            Assert.AreEqual(bodyResult, "A Body");
            Assert.AreEqual(ratingResult, 5);
        }

        [TestMethod]
        public void Setters_SetReviewData_Review()
        {
            Review testReview = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", Rating = 5 };

            testReview.ReviewId = 2;
            testReview.UserName = "A Different User";
            testReview.Body = "A Different Body";
            testReview.Rating = 3;

            Assert.AreEqual(testReview.ReviewId, 2);
            Assert.AreEqual(testReview.UserName, "A Different User");
            Assert.AreEqual(testReview.Body, "A Different Body");
            Assert.AreEqual(testReview.Rating, 3);
        }

        [TestMethod]
        public void FitChar_BodyFits255Char_Review()
        {
            Review passReview = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", Rating = 5 };
            Review failReview = new Review { ReviewId = 2, UserName = "A User", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", Rating = 5 };

            Assert.IsFalse(failReview.FitsCharacters());
            Assert.IsTrue(passReview.FitsCharacters());
        }
        [TestMethod]
        public void Rating_RatingIsValid_Bool()
        {
            Review passReview = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", Rating = 1 };
            Review failReview = new Review { ReviewId = 2, UserName = "A User", Body = "A Body", Rating = 7 };

            Assert.IsFalse(failReview.RatingIsValid());
            Assert.IsTrue(passReview.RatingIsValid());
        }
    }
}