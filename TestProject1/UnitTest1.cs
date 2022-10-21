namespace TestProject1
{
    public class UnitTest1
    {
        private readonly AsyncLocal<string> _al = 
            new AsyncLocal<string>() {  Value = "ctor-value" };

        [Fact]
        public async Task Test1()
        {
            //M1_sync();
            await M1();
            await M2();
        }

        private void M1_sync()
        {
            _al.Value = "42";
        }

        private async Task M1()
        {
            _al.Value = "42";
            await Task.Delay(10);
        }

        private async Task M2()
        {
            Assert.Equal("42", _al.Value);
            await Task.Delay(10);
        }
    }
}