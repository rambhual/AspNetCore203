using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore203.Infrastructure;
using AspNetCore203.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore203.Repository {
    public class SpeakerRepository : ISpeakerRepository {
        private readonly AspNetCore203DbContext _ctx;

        public SpeakerRepository (AspNetCore203DbContext ctx) {
            _ctx = ctx;
        }
        public async Task<bool> DelateSpeaker (Guid speakerId) {
            var deleteSpeaker = _ctx.Speakers.FirstOrDefaultAsync (x => x.SpeakerId == speakerId);
            _ctx.Remove (deleteSpeaker);
            try {
                return await _ctx.SaveChangesAsync () > 0 ? true : false;
            } catch (System.Exception ex) {

                throw new Exception ($"{ex.Message}");
            }
        }
        public async Task<IEnumerable<Speaker>> GetSpeakerAsync () {
            return await _ctx.Speakers.ToListAsync ();
        }
        public async Task<Speaker> GetSpeakerAsync (Guid speakerId) {
            return await _ctx.Speakers.FirstOrDefaultAsync (x => x.SpeakerId == speakerId);
        }

        public Task<Speaker> InsertSpeaker (Speaker speaker) {
            throw new NotImplementedException ();
        }

        public Task<bool> SaveSpeakerAsync () {
            throw new NotImplementedException ();
        }

        public Task<bool> SpeakerExist (Guid speakerId) {
            throw new NotImplementedException ();
        }

        public Task<bool> UpdateSpeaker (Speaker speaker) {
            throw new NotImplementedException ();
        }
    }
}