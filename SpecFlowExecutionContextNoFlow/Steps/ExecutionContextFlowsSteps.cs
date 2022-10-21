using System.Runtime.CompilerServices;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowExecutionContextNoFlow.Steps
{
    [Binding]
    public sealed class ExecutionContextFlowsSteps
    {
        private readonly AsyncLocal<string> _al = new() { Value = "x" };
        private readonly AsyncLocal<StrongBox<string>> _al2 = new() { Value = new StrongBox<string>("x")};

        [Given(@"AsyncLocal is set to (.+)")]
        public void GivenAsyncLocalIsSetTo(string data)
        {
            _al2.Value.Value.Should().Be("x");
            _al.Value.Should().Be("x");

            _al.Value = data;
            _al2.Value.Value = data;

            //await Task.Delay(100);

            _al2.Value.Value.Should().Be(data);
            _al.Value.Should().Be(data);
        }

        //[Then(@"the AsyncLocal is (.+)")]
        public void ThenTheAsyncLocalIs(string expected)
        {
            //await Task.Delay(100);
            _al2.Value.Value.Should().Be(expected);
            _al.Value.Should().Be(expected);
        }

        #region Case 1

        private readonly AsyncLocal<string> _case1Al = new();

        [Given(@"AsyncLocal is set \(case 1\)")]
        public void GivenAsyncLocalIsSetCase1()
        {
            _case1Al.Value = "41";
        }

        [Then(@"the AsyncLocal is verified \(case 1\) sync")]
        public void ThenTheAsyncLocalIsVerifiedCase1Sync()
        {
            _case1Al.Value.Should().Be("41");
        }

        [Then(@"the AsyncLocal is verified \(case 1\) async")]
        public async Task ThenTheAsyncLocalIsVerifiedCase1Async()
        {
            _case1Al.Value.Should().Be("41");
            await Task.Delay(10);
        }

        [Then(@"the AsyncLocal is verified \(case 1\) async void")]
        public async void ThenTheAsyncLocalIsVerifiedCase1AsyncVoid()
        {
            _case1Al.Value.Should().Be("41");
            await Task.Delay(10);
        }

        #endregion

        #region Case 2

        private readonly AsyncLocal<string> _case2Al = new() { Value = "42" };

        [Then(@"the AsyncLocal is verified \(case 2\) sync")]
        public void ThenTheAsyncLocalIsVerifiedCase2Sync()
        {
            _case2Al.Value.Should().Be("42");
        }

        [Then(@"the AsyncLocal is verified \(case 2\) async")]
        public async Task ThenTheAsyncLocalIsVerifiedCase2Async()
        {
            _case2Al.Value.Should().Be("42");
            await Task.Delay(10);
        }

        [Then(@"the AsyncLocal is verified \(case 2\) async void")]
        public async void ThenTheAsyncLocalIsVerifiedCase2AsyncVoid()
        {
            _case2Al.Value.Should().Be("42");
            await Task.Delay(10);
        }

        #endregion


        #region Case 3

        private static readonly AsyncLocal<string> _case3Al = new() { Value = "43" };

        [Then(@"the AsyncLocal is verified \(case 3\) sync")]
        public void ThenTheAsyncLocalIsVerifiedCase3Sync()
        {
            _case3Al.Value.Should().Be("43");
        }

        [Then(@"the AsyncLocal is verified \(case 3\) async")]
        public async Task ThenTheAsyncLocalIsVerifiedCase3Async()
        {
            _case3Al.Value.Should().Be("43");
            await Task.Delay(10);
        }

        [Then(@"the AsyncLocal is verified \(case 3\) async void")]
        public async void ThenTheAsyncLocalIsVerifiedCase3AsyncVoid()
        {
            _case3Al.Value.Should().Be("43");
            await Task.Delay(10);
        }

        #endregion


        #region Case 4

        private readonly AsyncLocal<string> _case4Al = new();

        [Given(@"AsyncLocal is set \(case 4\)")]
        public async Task GivenAsyncLocalIsSetCase4()
        {
            _case4Al.Value = "44";
            await Task.Delay(10);
        }

        [Then(@"the AsyncLocal is verified \(case 4\) sync")]
        public void ThenTheAsyncLocalIsVerifiedCase4Sync()
        {
            _case4Al.Value.Should().Be("44");
        }

        [Then(@"the AsyncLocal is verified \(case 4\) async")]
        public async Task ThenTheAsyncLocalIsVerifiedCase4Async()
        {
            _case4Al.Value.Should().Be("44");
            await Task.Delay(10);
        }

        [Then(@"the AsyncLocal is verified \(case 4\) async void")]
        public async void ThenTheAsyncLocalIsVerifiedCase4AsyncVoid()
        {
            _case4Al.Value.Should().Be("44");
            await Task.Delay(10);
        }

        #endregion

        #region Case 5

        private readonly AsyncLocal<string> _case5Al = new();

        [Given(@"AsyncLocal is set \(case 5\)")]
        public async void GivenAsyncLocalIsSetCase5()
        {
            _case5Al.Value = "45";
            await Task.Delay(10);
        }

        [Then(@"the AsyncLocal is verified \(case 5\) sync")]
        public void ThenTheAsyncLocalIsVerifiedCase5Sync()
        {
            _case5Al.Value.Should().Be("45");
        }

        [Then(@"the AsyncLocal is verified \(case 5\) async")]
        public async Task ThenTheAsyncLocalIsVerifiedCase5Async()
        {
            _case5Al.Value.Should().Be("45");
            await Task.Delay(10);
        }

        [Then(@"the AsyncLocal is verified \(case 5\) async void")]
        public async void ThenTheAsyncLocalIsVerifiedCase5AsyncVoid()
        {
            _case5Al.Value.Should().Be("45");
            await Task.Delay(10);
        }

        #endregion
    }
}