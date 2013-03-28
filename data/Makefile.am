# $Id: Makefile.am 58 2005-11-03 16:42:18Z ashtong $

# Desktop file
Desktopdir = $(datadir)/applications
Desktop_in_files = spamtrainer.desktop.in
Desktop_DATA = $(Desktop_in_files:.desktop.in=.desktop)

# GConf schemas
schemadir = $(GCONF_SCHEMA_FILE_DIR)
schema_in_files = spamtrainer.schemas
schema_DATA = $(schema_in_files)

if GCONF_SCHEMAS_INSTALL
install-data-local:
	echo Running from $(pwd)
	GCONF_CONFIG_SOURCE=$(GCONF_SCHEMA_CONFIG_SOURCE) \
		$(GCONFTOOL) --makefile-install-rule $(schema_DATA)
endif

EXTRA_DIST = $(Desktop_DATA) $(schema_DATA)
