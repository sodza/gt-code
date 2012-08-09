using System.ComponentModel.Composition;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace RegionExtension
{
// ReSharper disable UnusedMember.Global
   public static class TypeExports
   {
      [Export(typeof(ClassificationTypeDefinition))]
      [Name("region-foreground")]
      public static ClassificationTypeDefinition OrdinaryClassificationType;
   }
// ReSharper restore UnusedMember.Global

   [Export(typeof(EditorFormatDefinition))]
   [ClassificationType(ClassificationTypeNames = "region-foreground")]
   [Name("region-foreground")]
   [UserVisible(true)]
   [Order(After = Priority.High)]
   public sealed class RegionForeground : ClassificationFormatDefinition
   {
      public RegionForeground()
      {
         DisplayName = "Region Foreground";
         ForegroundColor = Colors.Gray;
      }
   }
}