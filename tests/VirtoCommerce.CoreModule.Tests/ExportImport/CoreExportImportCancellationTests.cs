using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using VirtoCommerce.CoreModule.Core.Currency;
using VirtoCommerce.CoreModule.Core.Package;
using VirtoCommerce.CoreModule.Web.ExportImport;
using VirtoCommerce.Platform.Core.ExportImport;
using Xunit;

namespace VirtoCommerce.CoreModule.Tests.ExportImport
{
    public class CoreExportImportCancellationTests
    {
        private readonly Mock<ICurrencyService> _currencyServiceMock;
        private readonly Mock<IPackageTypesService> _packageTypesServiceMock;
        private readonly CoreExportImport _exportImport;

        public CoreExportImportCancellationTests()
        {
            _currencyServiceMock = new Mock<ICurrencyService>();
            _currencyServiceMock.Setup(s => s.GetAllCurrenciesAsync())
                .ReturnsAsync([]);

            _packageTypesServiceMock = new Mock<IPackageTypesService>();
            _packageTypesServiceMock.Setup(s => s.GetAllPackageTypesAsync())
                .ReturnsAsync([]);

            _exportImport = new CoreExportImport(
                _currencyServiceMock.Object,
                _packageTypesServiceMock.Object,
                JsonSerializer.CreateDefault());
        }

        [Fact]
        public async Task ExportAsync_PreCancelledToken_ThrowsOperationCanceledException()
        {
            //Arrange
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            //Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(
                () => _exportImport.ExportAsync(Stream.Null, new ExportImportOptions(), _ => { }, cts.Token));
        }

        [Fact]
        public async Task ImportAsync_PreCancelledToken_ThrowsOperationCanceledException()
        {
            //Arrange
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            //Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(
                () => _exportImport.ImportAsync(Stream.Null, new ExportImportOptions(), _ => { }, cts.Token));
        }

    }
}
