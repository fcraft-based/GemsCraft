// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using fCraft.Players;
using fCraft.Utils;

namespace fCraft.Drawing.DrawOps {
    sealed class QuickPasteDrawOperation : PasteDrawOperation {
        public override string Name => Not ? "PasteNot" : "Paste";

        public QuickPasteDrawOperation( Player player, bool not )
            : base( player, not ) {
        }

        public override bool Prepare( Vector3I[] marks ) {
            return base.Prepare( new[] { marks[0], marks[0] } );
        }
    }
}
