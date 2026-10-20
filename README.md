# FreeTrain ExAVer — historical SVN r115 source snapshot

Preservation copy of FreeTrain EX A-version (FreeTrainEx-Aver), before the modern FreeTrain port. This is a source tree snapshot at SVN revision **r115**, not an import of full Subversion revision history. Any Git commits in this repository describe preservation work, not the original development history.

## Provenance

Original mirror download:

https://ftp.iij.ad.jp/pub/sourceforge.jp/scmarchive/g/freetrain-exav/svn/016a3f4b-25c1-4c19-bb38-6baf697ff05d/freetrain-exav-r115.zip

Archive: `freetrain-exav-r115.zip` (48,803,315 bytes).

SHA-256: `d5f5005c54d72b09edc2537ee0bb11a6227e3b5aeb204be063123da83e25fa09`.

All 6,324 original archive files are preserved byte-for-byte, including original notices, encodings, IDE files, binaries and directory structure. This README is the only added file. Locally generated Finder metadata is excluded because it was not part of the original archive. The archive's outer `freetrain-exav-r115/freetrain-exav/` wrapper is omitted from the repository root.

ZIP member timestamps range from 2008-11-15 to 2010-10-17. These are archive metadata, not independently verified commit or release dates. The local mirror was downloaded on 2026-04-25; that date is not the source's age.

## Preserved source lines

| Directory | Core assembly version | Latest member timestamp |
| --- | --- | --- |
| `trunk/` | 2.1.1.12 | 2010-10-17 |
| `Release1.0/trunk/` | 1.0.1.0 | 2010-03-25 |
| `Beta2.0.2.11/trunk/` | 2.0.2.11 | 2010-05-02 |
| `Beta2.2.0.1/trunk/` | 2.2.0.7 | 2010-10-17 |
| `ALPHA3/trunk/` | 3.1.1.4 | 2010-08-20 |
| `Beta2.0.2.11/ALPHA3/trunk/` | 3.0.1.11 | 2010-05-02 |

Directory names and nesting are retained exactly, even when they differ from assembly version numbers. This is ExAVer source; it does not establish a separate pristine OG FreeTrain baseline. No project code has been run or build compatibility verified.

## Copyright and licences

Original notices and licence texts remain in place. See `trunk/doc/readme_ftexav.txt`, `trunk/doc/readme.txt`, and the original `COPYING.txt` files. They identify FreeTrain copyright Kohsuke Kawaguchi et al. (2002 onward), FreeTrainEx copyright C477 et al. (2005 onward), and FreeTrainEx-Aver copyright FreeTrainEx-Aver Project et al. (2008 onward).

The FreeTrain/ExAVer notices specify LGPL version 2.1 or later, with individual plugin terms taking precedence where stated. This does not relicense third-party dependencies. The original README says DotNet Magic is not LGPL and permits redistribution. `tools/XmlPP.readme.txt` limits XmlPP use to the FreeTrain project.

The historical archive also includes Microsoft-copyrighted DirectShow SDK headers/samples and compiled `.lib` files in `Release1.0/trunk/lib/DirectShow.VideoRecorder/`. Their original notices are retained; this preservation copy makes no new grant of rights for third-party material. Applicable redistribution terms for those SDK components were not established from the included notices.
