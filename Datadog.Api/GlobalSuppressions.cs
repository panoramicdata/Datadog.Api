// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance",
	"CA1848:Use the LoggerMessage delegates",
	Justification = "Additional performance not considered necessary in this scenario",
	Scope = "namespaceanddescendants",
	Target = "~N:Datadog.Api")
]
[assembly: SuppressMessage("Design",
	"S2360:Optional parameters should not be used",
	Justification = "Refit maps optional parameters onto optional query-string parameters; overloads cannot express the combinations and a query-object parameter would break the published API",
	Scope = "namespaceanddescendants",
	Target = "~N:Datadog.Api.Interfaces")
]
