using FluentAssertions;
using NUnit.Framework;

namespace ShopNow.Tests
{
    public class CpfTests
    {
        [Test]
        public void ShouldBeAbleToValidateAnInvalidCpfWithRepeatedNumbers()
        {
            var cpf = new Cpf();
            const string invalidCpf = "111.111.111-11";

            var validateCpf = cpf.Validate(invalidCpf);

            validateCpf.Should().BeFalse();
        }
        
        [Test]
        public void ShouldBeAbleToValidateAnInvalidCpfWithLastDigitsInvalid()
        {
            var cpf = new Cpf();
            const string invalidCpf = "123.456.789-99";

            var validateCpf = cpf.Validate(invalidCpf);

            validateCpf.Should().BeFalse();
        }

        [TestCase("111.444.777-35")]
        [TestCase("935.411.347-80")]
        public void ShouldBeAbleToValidateAnValidCpf(string validCpf)
        {
            var cpf = new Cpf();

            var validateCpf = cpf.Validate(validCpf);

            validateCpf.Should().BeTrue();
        }
    }
}