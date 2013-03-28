# $Id: Makefile.am 59 2005-11-03 22:27:12Z ashtong $

AUTOMAKE_OPTIONS = check-news dist-bzip2 std-options
DISTCHECK_CONFIGURE_FLAGS = --disable-schemas-install
SUBDIRS = data resources src

# Required to allow editing with sed.
distcheck-hook:
	find $(distdir) -maxdepth 1 -type d -name src -exec chmod ug+w {} \;
