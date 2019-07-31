using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Extensions
{
    public static class RegexSeeds
    {
        public static void SeedRegex(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Regex>()
                .HasData(
                    new Regex() { Id = 1, Name = "Belarusian phone № (opt.code)", Value = @"^\+375\((17|25|29|33|44)\)\d{3}-?\d{2}-?\d{2}$" },
                    new Regex() { Id = 2, Name = "US phone №", Value = @"^(\([2-9]\d{2}\)|[2-9]\d{2})\-?[2-9]\d{2}\-?\d{4}$" },
                    new Regex() { Id = 3, Name = "UK phone №", Value = @"^((\+0?44\-?)?(\(0\))|0)((20[78]{1}\)?\-?[1-9]{1}[0-9]{2}\-?[0-9]{4})|([1-8]{1}[0-9]{3}\)?\-?[1-9]{1}[0-9]{2}\-?[0-9]{3}))$" },
                    new Regex() { Id = 4, Name = "URL with http(s)", Value = @"^https?://[A-Za-z]+(-?([A-Za-z]|\d)+)+\.([A-Za-z]|\d)+(-?([A-Za-z]|\d)+)*\.(com|net|by|ru|uk|biz|kr)/(([A-Za-z]|\d)+(-?([A-Za-z]|\d)+)*)+/{0,1}$" },
                    new Regex() { Id = 5, Name = "Date: MM/(Y)YYY", Value = @"^((0[1-9])|(1[012]))/[12]?\d{3}$" },
                    new Regex() { Id = 6, Name = "Date: DD Mon YYYY", Value = @"^(([012]\d|30) (Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)|31 (Jan|Mar|May|Jul|Aug|Oct|Dec)|[012]\d Feb) [012]\d{3}$" },
                    new Regex() { Id = 7, Name = "Date: YYYY/MM/DD with leap years", Value = @"^(((19|20)([2468][048]|[13579][26]|0[48])|2000)/02/29|((19|20)[0-9]{2}/(0[469]|11)/(0[1-9]|[12][0-9]|30)|(19|20)[0-9]{2}/(0[13578]|1[02])/(0[1-9]|[12][0-9]|3[01])|(19|20)[0-9]{2}/02/(0[1-9]|1[0-9]|2[0-8])))$" },
                    new Regex() { Id = 8, Name = "Time: HH:MM | HH/MM", Value = @"^([0-1][0-9]|[2][0-3])[:/\.]([0-5][0-9])$" },
                    new Regex() { Id = 9, Name = "Time: HH(:|.)MM[(:|.)SS] [AM|PM]", Value = @"^(([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))$" },
                    new Regex() { Id = 10, Name = "Time: HH:MM:SS", Value = @"^(([0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])$" },
                    new Regex() { Id = 11, Name = "DateTime: YYYY/MM/DD [T]HH:MM:SS", Value = @"^20\d{2}/((0[1-9])|(1[0-2]))/((0[1-9])|([1-2][0-9])|(3[0-1])) (T| )(([0-1][0-9])|(2[0-3])):([0-5][0-9]):([0-5][0-9])$" },
                    new Regex() { Id = 12, Name = "Email: RFC822", Value = @"^(\w[a-z0-9!#$%&'*\+/=\?\^_`{|}~]+(\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*)@([a-z0-9]([a-z0-9-]*[a-z0-9])?\.)+[a-z0-9]([a-z0-9-]*[a-z0-9])?|\[((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9])$" },
                    new Regex() { Id = 13, Name = "Simplified Email", Value = @"^((\w|\d)(\w|\d|\-|\.)?(\w|\d)+)+@{1}(((\w|\d|\-){1,67})|((\w|\d|\-)+\\.(\w|\d|\-){1,67}))\.(([a-zA-Z0-9]{2,4})(\.[a-zA-Z0-9]{2})?)$" },
                    new Regex() { Id = 14, Name = "Password", Value = @"^\w(\.|\*|\?|\d|\w|[!@#$%]){7,19}$" },
                    new Regex() { Id = 15, Name = "Guid with '-'", Value = @"^[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}$" },
                    new Regex() { Id = 16, Name = "Guid in braces", Value = @"^\{[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}\}" },
                    new Regex() { Id = 17, Name = "SSN with hyphens", Value = @"^\d{3}-\d{2}-\d{4}$" },
                    new Regex() { Id = 18, Name = "Simple SSN", Value = @"^\d{9}$" }
                );
        }
    }
}
