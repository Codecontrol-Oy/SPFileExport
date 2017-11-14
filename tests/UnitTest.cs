using System;
using Xunit;
using Moq;
using codecontrol.SPFileExport.Services;
using codecontrol.SPFileExport.Models;
using codecontrol.SPFileExport;

namespace tests
{
    public class UnitTest
    {
        [Fact]
        public void TestExport()
        {

            Mock<SPFileCollection> listMock = new Mock<SPFileCollection>();
            listMock.Setup(m => m.WriteFileList()).Callback(() => { });

            Mock<DBService> mock = new Mock<DBService>();
            mock.Setup(m => m.GetFileCount()).Returns(3);
            mock.Setup(m => m.Initialize()).Callback(() => { });
            mock.Setup(m => m.ExportFiles()).Callback(() => { }).Returns(listMock.Object);

            Mock<ConsoleService> mockConsole = new Mock<ConsoleService>();
            mockConsole.Setup(m => m.ReadInput()).Callback(() => {}).Returns("Y");
            mockConsole.Setup(m => m.WriteLineToConsole(It.IsAny<string>())).Callback(() => {});
            mockConsole.Setup(m => m.WriteToConsole(It.IsAny<string>())).Callback(() => {});


            Program.MockMain(mock.Object,mockConsole.Object);

            mock.Verify(m => m.GetFileCount(),Times.Once());
            mock.Verify(m => m.Initialize(),Times.Once());
            mock.Verify(m => m.ExportFiles(),Times.Once);
            listMock.Verify(m => m.WriteFileList(),Times.Once());
        }
    }
}