using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLAPI.Models
{
	public class Platform
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string LicenseKey { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime CreatedAt { get; set; } = DateTime.Today;

		public ICollection<Command> Commands { get; set; } = new List<Command>();
	}
}