using ValidatorProject;
namespace EvaluationSampleCode.UnitTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void CheckNumberOfDashes_WithTwoDashes_ReturnTrue()
        {
            var validator = new Validator("21-02-2024");

            var result = validator.CheckNumberOfDashes();

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("21022024")]
        [DataRow("2102-2024")]
        [DataRow("21-02-20-24")]
        [DataRow("21-02-20--24")]
        public void CheckNumberOfDashes_WithOtherThanTwoDashes_ReturnFalse(string date)
        {
            var validator = new Validator(date);

            var result = validator.CheckNumberOfDashes();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckElementsAreNumerics_WithNumerics_ReturnTrue()
        {
            var validator = new Validator("21-02-2024");

            var result = validator.CheckElementsAreNumerics();

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("day-02-2024")]
        [DataRow("21-month-2024")]
        [DataRow("21-02-year")]
        [DataRow("day-month-year")]
        public void CheckElementsAreNumerics_WithNonNumerics_ReturnFalse(string date)
        {
            var validator = new Validator(date);

            var result = validator.CheckElementsAreNumerics();

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(31)]
        [DataRow(21)]
        public void CheckDayValue_WithCorrectDay_ReturnTrue(int day)
        {
            var validator = new Validator(String.Concat(day, "-02-2024"));

            var result = validator.CheckDayValue();

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(32)]
        [DataRow(550)]
        public void CheckDayValue_WithIncorrectValue_ReturnFalse(int day)
        {
            var validator = new Validator(String.Concat(day, "-02-2024"));

            var result = validator.CheckDayValue();

            Assert.IsFalse(result);
        }

        // Les tests pour CheckMonth et CheckYear ont été intentionnellement ignorés pour gagner du temps en corrigé

        [TestMethod]
        [DataRow("day-02-2024")]
        [DataRow("21-month-2024")]
        [DataRow("21-02-year")]
        [DataRow("day-month-year")]
        public void ThrowExceptionIfElementsAreNotNumeric_WithNonNumerics_ThrowsArgumentException(string date)
        {
            var validator = new Validator(date);

            Assert.ThrowsException<ArgumentException>(() => validator.ThrowExceptionIfElementsAreNotNumeric());
        }

        [TestMethod]
        public void ThrowExceptionIfElementsAreNotNumeric_WithNumerics_DoesntThrowException()
        {
            var validator = new Validator("21-02-2024");

            validator.ThrowExceptionIfElementsAreNotNumeric();
        }
    }
}
