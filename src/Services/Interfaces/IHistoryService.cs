using System.Collections.Generic;
using System.Threading.Tasks;
using Imago.Models;

namespace Imago.Services.Interfaces
{
	public interface IHistoryService
	{
		Task<ICollection<CapturedMedia>> GetHistory();
	}
}