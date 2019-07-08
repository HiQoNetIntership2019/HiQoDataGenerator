﻿using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldType>()
                .HasData(
                    new FieldType() { Id = 1, Name = "byte" },
                    new FieldType() { Id = 2, Name = "int" },
                    new FieldType() { Id = 3, Name = "double" },
                    new FieldType() { Id = 4, Name = "decimal" },
                    new FieldType() { Id = 5, Name = "complex" },
                    new FieldType() { Id = 6, Name = "string" },
                    new FieldType() { Id = 7, Name = "bool" },
                    new FieldType() { Id = 8, Name = "date" },
                    new FieldType() { Id = 9, Name = "time" },
                    new FieldType() { Id = 10, Name = "datetime" },
                    new FieldType() { Id = 11, Name = "enum" },
                    new FieldType() { Id = 12, Name = "guid" }
                );

            modelBuilder.Entity<Constraint>()
                .HasData(
                    new Constraint() { Id = 1, Name = "min value", Description = "Minimal value for a numeric field." },
                    new Constraint() { Id = 2, Name = "max value", Description = "Maximal value for a numeric field." },
                    new Constraint() { Id = 3, Name = "separator", Description = "Comma or dot separator for a numeric field." },
                    new Constraint() { Id = 4, Name = "max digits", Description = "Can be applied to a decimal field." },
                    new Constraint() { Id = 5, Name = "decimal place", Description = "Separator position for a decimal field." },
                    new Constraint() { Id = 6, Name = "max a value", Description = "Maximal re part value for a complex field." },
                    new Constraint() { Id = 7, Name = "min a value", Description = "Minimal re part value for a complex field." },
                    new Constraint() { Id = 8, Name = "max b value", Description = "Maximal img part value for a complex field." },
                    new Constraint() { Id = 9, Name = "min b value", Description = "Minimal img part value for a complex field." },
                    new Constraint() { Id = 10, Name = "separator", Description = "Comma or dot separator for a numeric field." },
                    new Constraint() { Id = 11, Name = "regex", Description = "Custom or defined regexp applied to a field." },
                    new Constraint() { Id = 12, Name = "encoding", Description = "Encoding type for a string field." },
                    new Constraint() { Id = 13, Name = "start date", Description = "The left boundary for date [time] field." },
                    new Constraint() { Id = 14, Name = "end date", Description = "The right boundary for date [time] field." },
                    new Constraint() { Id = 15, Name = "timezone", Description = "Timezone applied to date [time] field." },
                    new Constraint() { Id = 16, Name = "format", Description = "Representation format for a date [time] field." },
                    new Constraint() { Id = 17, Name = "min length", Description = "Minimal length of a string field." },
                    new Constraint() { Id = 18, Name = "max length", Description = "Maximal length of a string field." }
                );

            modelBuilder.Entity<FieldTypeConstraint>()
                .HasData(
                    #region Constraints for byte
                    new FieldTypeConstraint() { Id = 1, FieldTypeId = 1, ConstraintId = 1 },
                    new FieldTypeConstraint() { Id = 2, FieldTypeId = 1, ConstraintId = 2 },
                    #endregion

                    #region Constraints for int
                    new FieldTypeConstraint() { Id = 3, FieldTypeId = 2, ConstraintId = 1 },
                    new FieldTypeConstraint() { Id = 4, FieldTypeId = 2, ConstraintId = 2 },
                    #endregion

                    #region Constraints for double
                    new FieldTypeConstraint() { Id = 5, FieldTypeId = 3, ConstraintId = 1 },
                    new FieldTypeConstraint() { Id = 6, FieldTypeId = 3, ConstraintId = 2 },
                    new FieldTypeConstraint() { Id = 7, FieldTypeId = 3, ConstraintId = 3 },
                    #endregion

                    #region Constraints for decimal
                    new FieldTypeConstraint() { Id = 8, FieldTypeId = 4, ConstraintId = 3 },
                    new FieldTypeConstraint() { Id = 9, FieldTypeId = 4, ConstraintId = 4 },
                    new FieldTypeConstraint() { Id = 10, FieldTypeId = 4, ConstraintId = 5 },
                    #endregion

                    #region Constraints for complex
                    new FieldTypeConstraint() { Id = 11, FieldTypeId = 5, ConstraintId = 6 },
                    new FieldTypeConstraint() { Id = 12, FieldTypeId = 5, ConstraintId = 7 },
                    new FieldTypeConstraint() { Id = 13, FieldTypeId = 5, ConstraintId = 8 },
                    new FieldTypeConstraint() { Id = 14, FieldTypeId = 5, ConstraintId = 9 },
                    #endregion

                    #region Constraints for string
                    new FieldTypeConstraint() { Id = 15, FieldTypeId = 6, ConstraintId = 17 },
                    new FieldTypeConstraint() { Id = 16, FieldTypeId = 6, ConstraintId = 18 },
                    new FieldTypeConstraint() { Id = 17, FieldTypeId = 6, ConstraintId = 11 },
                    new FieldTypeConstraint() { Id = 18, FieldTypeId = 6, ConstraintId = 12 },
                    #endregion

                    #region Constraints for date
                    new FieldTypeConstraint() { Id = 19, FieldTypeId = 8, ConstraintId = 13 },
                    new FieldTypeConstraint() { Id = 20, FieldTypeId = 8, ConstraintId = 14 },
                    new FieldTypeConstraint() { Id = 21, FieldTypeId = 8, ConstraintId = 15 },
                    new FieldTypeConstraint() { Id = 22, FieldTypeId = 8, ConstraintId = 16 },
                    #endregion

                    #region Constraints for time
                    new FieldTypeConstraint() { Id = 23, FieldTypeId = 9, ConstraintId = 13 },
                    new FieldTypeConstraint() { Id = 24, FieldTypeId = 9, ConstraintId = 14 },
                    new FieldTypeConstraint() { Id = 25, FieldTypeId = 9, ConstraintId = 15 },
                    new FieldTypeConstraint() { Id = 26, FieldTypeId = 9, ConstraintId = 16 },
                    #endregion

                    #region Constraints for datetime
                    new FieldTypeConstraint() { Id = 27, FieldTypeId = 10, ConstraintId = 13 },
                    new FieldTypeConstraint() { Id = 28, FieldTypeId = 10, ConstraintId = 14 },
                    new FieldTypeConstraint() { Id = 29, FieldTypeId = 10, ConstraintId = 15 },
                    new FieldTypeConstraint() { Id = 30, FieldTypeId = 10, ConstraintId = 16 },
                     #endregion

                    #region Constraints for guid
                    new FieldTypeConstraint() { Id = 31, FieldTypeId = 11, ConstraintId = 11 }
                    #endregion
                );
        }
    }
}