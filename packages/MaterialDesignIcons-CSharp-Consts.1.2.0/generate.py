#!/usr/bin/python3
# -*- coding: utf-8 -*-

import sys
from upstream_parser import mdi_upstream

icon_prefix = 'mdi-'
output_file = 'content/Helpers/MaterialDesignIcons.cs.pp'
output_file_codepoints = 'content/Helpers/MaterialDesignIconsCodepoints.cs.pp'
output_prefix = """namespace $rootnamespace$.Helpers
{
    /**
     * MaterialDesignIcons-C#-Consts
     * https://github.com/chteuchteu/MaterialDesignIcons-CSharp-Consts
     *
     * MaterialDesignIcons v#VERSION#
     */
    public abstract class #CLASSNAME#
    {
"""

output_sufix = """    }
}
"""

output_type_name = 1
output_type_codepoint = 2


def write_to_file(filename, output_type):
    with open(filename, 'w') as output:
        output.truncate()

        classname = 'Mdi' if output_type == output_type_name else 'MdiCodepoints'

        output.writelines(
            output_prefix.replace('#VERSION#', meta['version']).replace('#CLASSNAME#', classname)
        )

        for icon in meta['icons']:
            # Remove dashes, capitalize
            var_name = icon['name'].replace('-', ' ').title().replace(' ', '')
            var_value = icon_prefix + icon['name'] if output_type == output_type_name else icon['codepoint']

            output.write('        public const string {} = "{}";\n'.format(
                var_name, var_value
            ))

        output.writelines(output_sufix)

        print("Generated {} with {} variables".format(filename, len(meta['icons'])))

# Download & parse input file
meta = mdi_upstream.fetch_meta(None, True)

if len(meta['icons']) == 0:
    print('Could not find variables.')
    sys.exit(1)

# Write to output files
write_to_file(output_file, output_type_name)
write_to_file(output_file_codepoints, output_type_codepoint)
