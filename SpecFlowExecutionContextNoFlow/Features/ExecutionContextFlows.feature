Feature: Execution Context flows between steps
	As an engineer
	I want to have the ExecutionContext flow back up the call stack
	So that other steps, hooks and the SUT can access the correct data
	e.g. AsyncLocal<T> & HttpContext.Current

Scenario Outline: 1. set AL in sync stepdef, read it in sync step def
	Given AsyncLocal is set (case 1)
	Then the AsyncLocal is verified (case 1) <verification>
Examples: 
	| verification |
	| sync         |
	| async        |
	| async void   |

Scenario Outline: 2. set AL in ctor, read it in sync/async step def
	Then the AsyncLocal is verified (case 2) <verification>
Examples: 
	| verification |
	| sync         |
	| async        |
	| async void   |

Scenario Outline: 3. set AL in static ctor, read it in sync/async step def
	Then the AsyncLocal is verified (case 3) <verification>
Examples: 
	| verification |
	| sync         |
	| async        |
	| async void   |

Scenario Outline: 4. set AL in async step def, read it in sync/async step def
	Given AsyncLocal is set (case 4)
	Then the AsyncLocal is verified (case 4) <verification>
Examples: 
	| verification |
	| sync         |
	| async        |
	| async void   |


Scenario Outline: 5. set AL in async void step def, read it in sync/async step def
	Given AsyncLocal is set (case 5)
	Then the AsyncLocal is verified (case 5) <verification>
Examples: 
	| verification |
	| sync         |
	| async        |
	| async void   |

