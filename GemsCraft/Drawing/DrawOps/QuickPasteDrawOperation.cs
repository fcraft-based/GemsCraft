// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using GemsCraft.Players;
using GemsCraft.Utils;

namespace GemsCraft.Drawing.DrawOps {
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
