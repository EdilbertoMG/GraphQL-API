using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.Models
{
	public class Command
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string HowTo { get; set; }

		[Required]
		public string CommandLine { get; set; }

		[Required]
		public int PlatformId { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime CreatedAt { get; set; } = DateTime.Today;

		public Platform Platform { get; set; }
	}
}