using System;
using System.IO;
using System.Text;
using Xunit;

namespace Trivia.Tests
{
    public class GameTest
    {
        [Fact (Skip = "true")]
        public void generate_a_golden_master()
        {
            var path = "../../../GoldenMasterOutputs";
            Directory.CreateDirectory(path);

            for (var i = 0; i <= 200; i++)
            {
                var fileName = $"gameOutput{i}.txt";
                using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                using var outputStream = new StreamWriter(fileStream);
                Console.SetOut(outputStream);
                GameRunner.Main(new [] {i.ToString()});
            }
        }

        [Fact]
        public void verify_golden_master_content()
        {
            var path = "../../../GoldenMasterOutputs";
            for (var i = 0; i <= 200; i++)
            {
                var fileName = $"gameOutput{i}.txt";

                var expectedContent = new StringBuilder();
                Console.SetOut(new StringWriter(expectedContent));

                GameRunner.Main(new[] { i.ToString() });
                Assert.Equal(expectedContent.ToString(), File.ReadAllText(Path.Combine(path, fileName)));
            }
        }
    }
}