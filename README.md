README
======

Spam Trainer simplifies the process of training spam filtering software 
(e.g. Spambayes, SpamAssassin or crm114) that has the ability to "learn"
which messages look like good email (ham) and which ones are likely to be
unsolicited (spam).

Not all email clients have Spam filtering (and training) built in, and
training external filtering programs can be fiddly. Spam Trainer was 
written to provide easy (drag and drop) training from within the 
Evolution mail client, and should work just as well with any email client
that supports the drag and drop protocol implemented within the GTK+ 
toolkit.

Requirements
------------

Spam Trainer requires GNOME, Mono 1.0 and GTK#. GNOME should be
available pre-packaged for your operating system (unless you're using
Windows, which isn't supported). Mono and GTK# may be available with
your operating system. Otherwise they can be downloaded from the Mono
web site:

    http://www.mono-project.com/download/

Spam Trainer expects the dropped file to be passed to it in the form
of a local URI (e.g. "file:///tmp/evolution/path/to/message"). Any
email client that supports drag-and-drop in GNOME is likely to work
just as well (it has been tested with Evolution 1.x and 2.x).
Success/failure reports with other email clients would be most welcome.

Installation
------------

Pre-compiled packages for your operating system may available.

Otherwise, the compilation and installation process is straightforward,
though you will need to install some Mono development packages first.
Compile and install Spam Trainer as follows:
 
    $ ./configure
    $ make
    # make install

By default Spam Trainer will be installed into /usr/local. When 
installing on Ubuntu Linux (for example) I run configure like this, so
that the Spam Trainer icon automatically appears in the GNOME menu:

    $ ./configure --prefix=/usr --sysconfdir=/etc

It's not very good style to install it into /usr and /etc (only your
operating system's package manager should be managing the files in
these directories) but it does mean that GNOME can find all the Spam
Trainer files properly. Your mileage may vary.

Usage
-----

When you run Spam Trainer a small window appears with two icons; one
representing ham and the other representing spam. Dragging and dropping
an email message from your email program (or some other drag-and-drop 
capable program) onto either icon will train your spam filter accordingly.

In order to configure Spam Trainer to work with your spam filtering
software you will need to configure the commands that are used to train
ham and spam messages, respectively. Right click on the main window in
order to access the preferences. When entering the training commands
use %f to represent the filename of the message on which you are training.
For example, to use the SpamBayes sb_filter.py program to train a message
as spam enter:

    sb_filter.py -s < %f

Customization
-------------

If you would like to change the icons used to represent ham and spam
(the defaults aren't very imaginative) just drop some PNG files over the
top of the ham.png and spam.png files in the resources/ directory and
re-install.
