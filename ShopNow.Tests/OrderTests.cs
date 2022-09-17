using FluentAssertions;
using NUnit.Framework;
using System;

namespace ShopNow.Tests
{
    public class OrderTests
    {
        [Test]
        public void ShouldNotBeAbleToMakeAnOrderWithInvalidCpf()
        {
            var act = () => new Order("18731465022");
            
            act.Should()
               .Throw<InvalidOperationException>()
               .WithMessage("Cpf is invalid!");
        }

        [Test]
        public void ShouldBeAbleToMakeAnOrderWithValidCpf()
        {
            var act = () => new Order("18731465072");

            act.Should()
               .NotThrow<InvalidOperationException>();
        }

        [Test]
        public void ShouldBeAbleToMakeAnOrderWithDescriptionPriceAndCount()
        {
            var order = new Order("18731465072");

            order.AddItem(new Item("Smartphone", 1000.00M, 2));
            order.AddItem(new Item("Table", 400.00M, 2));

            order.GetTotal()
                 .Should()
                 .Be(2800.00M);
        }

        [Test]
        public void ShouldBeAbleToApplyDiscountInAnOrder()
        {
            var coupon = new Coupon("VALE20", 20);
            var order = new Order("18731465072", coupon);

            order.AddItem(new Item("Guitarra", 1000, 1));
            order.AddItem(new Item("Amplificador", 5000, 1));
            order.AddItem(new Item("Cabo", 30, 3));

            order.GetTotal()
                 .Should()
                 .Be(4872M);
        }
    }
}
