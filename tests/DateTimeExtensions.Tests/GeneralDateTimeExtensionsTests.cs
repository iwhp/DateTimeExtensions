using System;
using NUnit.Framework;

namespace DateTimeExtensions.Tests
{
    [TestFixture]
    public class GeneralDateTimeExtensionsTests
    { 
        [Test]
        public void SetTime_Preserves_Utc_Kind()
        {
            // Arrange  
            DateTime utcDate = new(2026, 7, 7, 14, 0, 0, DateTimeKind.Utc);

            // Act  
            DateTime result = utcDate.SetTime(15);
            Assert.Multiple(() =>
            {

                // Assert  
                Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Utc));
                Assert.That(result.Hour, Is.EqualTo(15));
                Assert.That(result.Minute, Is.EqualTo(0));
                Assert.That(result.Second, Is.EqualTo(0));
                Assert.That(result.Millisecond, Is.EqualTo(0));
            });
        }

        [Test]
        public void SetTime_Preserves_Local_Kind()
        {
            // Arrange  
            DateTime localDate = new(2026, 7, 7, 14, 0, 0, DateTimeKind.Local);

            // Act  
            DateTime result = localDate.SetTime(15, 30);
            Assert.Multiple(() =>
            {

                // Assert  
                Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Local));
                Assert.That(result.Hour, Is.EqualTo(15));
                Assert.That(result.Minute, Is.EqualTo(30));
            });
        }

        [Test]
        public void SetTime_Preserves_Unspecified_Kind()
        {
            // Arrange  
            DateTime unspecifiedDate = new(2026, 7, 7, 14, 0, 0, DateTimeKind.Unspecified);

            // Act  
            DateTime result = unspecifiedDate.SetTime(15, 30, 45);
            Assert.Multiple(() =>
            {

                // Assert  
                Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Unspecified));
                Assert.That(result.Hour, Is.EqualTo(15));
                Assert.That(result.Minute, Is.EqualTo(30));
                Assert.That(result.Second, Is.EqualTo(45));
            });
        }

        [Test]
        public void SetTime_With_Milliseconds_Preserves_Kind()
        {
            // Arrange  
            DateTime utcDate = new(2026, 7, 7, 14, 0, 0, DateTimeKind.Utc);

            // Act  
            DateTime result = utcDate.SetTime(15, 30, 45, 500);
            Assert.Multiple(() =>
            {

                // Assert  
                Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Utc));
                Assert.That(result.Hour, Is.EqualTo(15));
                Assert.That(result.Minute, Is.EqualTo(30));
                Assert.That(result.Second, Is.EqualTo(45));
                Assert.That(result.Millisecond, Is.EqualTo(500));
            });
        }

        [Test]
        [TestCase(DateTimeKind.Utc)]
        [TestCase(DateTimeKind.Local)]
        [TestCase(DateTimeKind.Unspecified)]
        public void SetTime_All_Overloads_Preserve_Kind(DateTimeKind kind)
        {
            // Arrange  
            DateTime originalDate = new(2026, 7, 7, 14, 0, 0, kind);
            Assert.Multiple(() =>
            {

                // Act & Assert - Test all overloads  
                Assert.That(originalDate.SetTime(15).Kind, Is.EqualTo(kind));
                Assert.That(originalDate.SetTime(15, 30).Kind, Is.EqualTo(kind));
                Assert.That(originalDate.SetTime(15, 30, 45).Kind, Is.EqualTo(kind));
                Assert.That(originalDate.SetTime(15, 30, 45, 500).Kind, Is.EqualTo(kind));
            });
        }
    }
}