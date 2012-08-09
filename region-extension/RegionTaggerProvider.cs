using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace RegionExtension
{
   [Export(typeof(IViewTaggerProvider))]
   [ContentType("any")]
   [TagType(typeof(ClassificationTag))]
   public sealed class RegionTaggerProvider : IViewTaggerProvider
   {
      // ReSharper disable InconsistentNaming
      [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate")]
      [Import]
      public IClassificationTypeRegistryService Registry;
      // ReSharper restore InconsistentNaming

      // ReSharper disable MemberCanBePrivate.Global
      [Import]
      internal ITextSearchService TextSearchService { get; set; }
      // ReSharper restore MemberCanBePrivate.Global

      public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
      {
         if (buffer != textView.TextBuffer)
         {
            return null;
         }

         IClassificationType classificationType = Registry.GetClassificationType("region-foreground");
         return new RegionTagger(textView, TextSearchService, classificationType) as ITagger<T>;
      }
   }
}