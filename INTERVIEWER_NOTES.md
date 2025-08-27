# Interviewer Notes - Parking Lot System

## Interview Level
**Target: SWE I / SWE II**

## Time Allocation (90 minutes)
- 5 min: Problem understanding and Q&A
- 70 min: Implementation
- 10 min: Testing and debugging
- 5 min: Discussion about design choices

## Expected Solution Complexity

### For SWE I:
- Complete basic parking/unparking functionality
- Fix all core unit tests
- Implement basic fee calculation
- Handle edge cases properly

### For SWE II:
- All SWE I requirements plus:
- Implement 2-3 additional features
- Consider concurrency issues (discuss if not implement)
- Optimize space allocation algorithm
- Add comprehensive error handling

## Key Evaluation Points

### 1. Problem Solving (30%)
- **Understanding requirements**: Do they ask clarifying questions?
- **Edge cases**: Empty lot, full lot, invalid vehicle types
- **Algorithm selection**: Efficient space finding algorithm

### 2. Code Quality (25%)
- **Clean code**: Naming, formatting, organization
- **SOLID principles**: Single responsibility, dependency injection
- **Error handling**: Custom exceptions, validation

### 3. OOP Design (20%)
- **Abstraction**: Proper use of interfaces
- **Encapsulation**: Private fields, public methods
- **Inheritance**: Vehicle hierarchy if used
- **Composition**: Proper relationships between classes

### 4. Testing (15%)
- **Test understanding**: Can they read and fix failing tests?
- **Test coverage**: Do they add tests for new features?
- **Edge case testing**: Boundary conditions

### 5. Performance (10%)
- **Data structure choice**: Dictionary vs List for lookups
- **Algorithm efficiency**: O(1) vs O(n) operations
- **Memory management**: Not keeping unnecessary data

## Common Pitfalls to Watch For

1. **Not reading existing code**: Starting from scratch instead of understanding stubs
2. **Over-engineering**: Creating complex hierarchies for simple problems
3. **Poor error handling**: Returning null instead of throwing exceptions
4. **Ignoring tests**: Not running tests frequently during development
5. **Time management**: Spending too much time on one feature

## Hints to Provide (if struggling)

### After 20 minutes:
- "Have you looked at the test file to understand expected behavior?"
- "Consider using a Dictionary for O(1) lookups"

### After 40 minutes:
- "Focus on making the core tests pass first"
- "The space allocation can use a simple first-fit algorithm"

### After 60 minutes:
- "Make sure basic parking/unparking works before additional features"
- "Check that you're handling the 'full parking lot' scenario"

## Good Signs

- Reads through all provided code before starting
- Runs tests early and often
- Asks about business rules (e.g., "Can a car park in a large space?")
- Implements incrementally, testing each piece
- Uses meaningful variable/method names
- Handles edge cases without prompting

## Red Flags

- Deletes provided code structure
- Doesn't run tests until the end
- No error handling
- Hardcoded values instead of configuration
- Copy-paste coding without understanding
- Unable to debug failing tests

## Sample Follow-up Questions

1. **Design**: "How would you handle multiple parking levels?"
2. **Scalability**: "How would this work with 10,000 parking spaces?"
3. **Concurrency**: "What if multiple threads try to park simultaneously?"
4. **Features**: "How would you implement a reservation system?"
5. **Database**: "How would you persist this data?"

## Scoring Rubric

### Pass (SWE I):
- All core tests pass
- Basic features implemented correctly
- Code is readable and organized
- Shows understanding of OOP concepts

### Strong Pass (SWE I) / Pass (SWE II):
- All core tests pass
- 1-2 additional features implemented
- Good error handling
- Efficient algorithms
- Some test coverage for new features

### Strong Pass (SWE II):
- All core tests pass
- 2-3 additional features with tests
- Excellent code organization
- Performance considerations
- Discusses advanced topics (concurrency, scaling)

## Complete Solution Overview

The complete solution should have:

1. **Vehicle abstract class** with Motorcycle, Car, Truck implementations
2. **ParkingSpace class** with space type, ID, and occupied status
3. **ParkingTicket class** with unique ID, timestamps, vehicle info
4. **ParkingLotService** implementing:
   - Space allocation algorithm (first-fit or best-fit)
   - Ticket generation and validation
   - Space availability tracking
   - Fee calculation based on duration
5. **Custom exceptions** for parking errors
6. **Thread-safe operations** (bonus)

## Interview Adjustments

### If candidate finishes early:
- Ask them to implement reservation system
- Discuss database design
- Code review their solution together
- Ask about testing strategies

### If candidate is struggling:
- Suggest focusing on core functionality only
- Provide method signatures
- Pair program on one feature
- Reduce scope to just parking/unparking

## Notes Section
_Use this space during the interview to track observations:_

- Problem understanding: ___/10
- Coding speed: ___/10
- Code quality: ___/10
- Testing approach: ___/10
- Communication: ___/10
- Overall recommendation: [Strong No / No / Neutral / Yes / Strong Yes]

Additional comments:
_____________________________
_____________________________
_____________________________