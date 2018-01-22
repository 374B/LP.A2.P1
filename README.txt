The solution should work out of the box.
There is an in-memory database with some fake seed data.
When API is started it should launch the swagger UI, which provides both API documentation and a test harness.
If it does not launch, it can be accessed at /swagger

The focus was on demonstrating a variety of concepts rather than focusing on one area in particular.

API:
- Should be using response specific DTO classes to support extension
- Paging has not been implemented

Tests:
- There are a limited number of tests to demonstrate concepts, not completeness.

Misc
- There is no logging