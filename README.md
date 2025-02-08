# TestAccountability
A tool that helps connect tests in .NET code to issues and feature definitions

TestAccountability is not the final name for this library, but is a placeholder to get us started and iterating on some of the ideas discussed.

## Concept

We should be able to decorate our tests with an atteibute to indicate which feature or issue the test addresses. This will
then let us generate reports at CI time that show what features are completed and what issues are fixed. Additionally, we can
show which features or issues are broken when tests failed.