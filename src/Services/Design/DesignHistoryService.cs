using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imago.Models;
using Imago.Services.Interfaces;

namespace Imago.Services.Design
{
	public class DesignHistoryService : IHistoryService
	{
		public Task<ICollection<CapturedMedia>> GetHistory()
		{
			return Task.FromResult<ICollection<CapturedMedia>>(new[]
			{
				new CapturedMedia
				{
					FileName = "Captured file 1.png",
					CaptureDate = DateTimeOffset.Now.Subtract(new TimeSpan(1, 2, 3, 4))
				},
				new CapturedMedia
				{
					FileName = "Captured file 2.png",
					CaptureDate = DateTimeOffset.Now.Subtract(new TimeSpan(0, 1, 9, 8))
				}
			});
		}
	}
}
