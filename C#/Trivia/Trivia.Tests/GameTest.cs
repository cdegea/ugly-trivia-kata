using System;
using System.IO;
using System.Text;
using Xunit;

namespace Trivia.Tests
{
    public class GameTest
    {
        private const string path = "../../../GoldenMasterOutputs";

        [Fact (Skip = "true")]
        public void generate_a_golden_master()
        {
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