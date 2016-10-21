# Logger
Customized Logger which includes a text,DB and Event Logging modes. Easy to scale up with any logger type.

There is a tester console project to demonstrate the application.
If event logger is required with a new source, it is recommended to build the utility project and execute the command "installutil <utility dll assmebly path>" in visual studio with n admin account.
App config contains the varibles under app settings section.

This is a scalable solution. If there is a new logger simply add the new logger class to the logger project. Implement the Ilogger interface within the class. Tester can consume the newly added logger with no changes to the existing modules.

