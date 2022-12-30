# C# SVN PreCommit Hook Example

Just a quick example project that demonstrates how to work with SVN pre-commit hooks.
<br><br>
There are 3 example classes in the project;<br>
<ul>
<li>Example Commit Text Test - Validate a commit based on the commit message.
</li>
<li>
Example File Name Test - Validate a commit based on the names of the files committed.
</li>
<li>
Example File Text Test - Validate a commit based on the contents of the files committed.
</li>
</ul>
<h1>Usage</h1>
To use the project, create an .exe and call it from the pre-commit hook:
<br><br>
<img src="https://i.imgur.com/oy7igSV.png">
<h1>Configuration</h1>
In the app.config there are a number of files that allow you to enable/disable tests individually or universally. 
<br><br>
<b>Any new tests need to be included in the config or they will always return false</b>.
<h1>Errors</h1>
Error codes are defined in the Error enum and error messages in the ErrorHelper class.
<br><br>
The error codes are returned to the SVN client, but the error messages are simply logged internally.
<h1>Testing</h1>
Testing is a pain because in order to run the SVN command line utilities you need a transaction ID (TXN). In SVN, the TXN only lasts for the duration of the commit; typically about 2-3 seconds, which isn't long enough to test the code.
<br><br>
My admittedly hacky workaround was to write a separate test project with a pre-commit hook that would force the console to sleep for 60 seconds:
<br><br>
<img src="https://i.imgur.com/g10nTUq.png">
This gave me enough time to increment a hard-coded TXN, which allowed me to test the code:
<br><br>
<img src="https://i.imgur.com/IbIy08L.png">
