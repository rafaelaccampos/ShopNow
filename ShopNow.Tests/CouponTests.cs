using FluentAssertions;
using NUnit.Framework;
using System;

namespace ShopNow.Tests
{
    public class CouponTests
    {
        [Test]
        public void ShouldBeAbleToCalculateDiscount()
        {
            var coupon = new Coupon("VALE35", 35);

            coupon.AddDiscount(1000);

            coupon.GetDiscount()
                .Should()
                .Be(350);
        }

        [Test]
        public void ShouldNotBeAbleToApplyDiscountIfCouponHasExpired()
        {
            var expireDate = DateTime.Now.AddDays(-2);
            var actualDate = DateTime.Now;

            var coupon = new Coupon("VALE20", 20, expireDate, actualDate);

            coupon.AddDiscount(1000);

            coupon.GetDiscount()
                  .Should()
                  .Be(0);
        }
    }
}
